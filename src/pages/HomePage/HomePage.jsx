import React, { useContext, useEffect, useState } from "react";
import "./HomePage.css";

import Banner from "../../components/Banner/Banner";
import MainContent from "../../components/MainContent/MainContent";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import Title from "../../components/Title/Title";
import NextEvent from "../../components/NextEvent/NextEvent";
import PastEvent from "../../components/PastEvent/PastEvent";
import Container from "../../components/Container/Container";
import api from "../../Services/Service";
import Notification from "../../components/Notification/Notification";
import { nextEventResource, pastEentResource, myEventsResource, presencesEventResource } from "../../Services/Service";
import { UserContext } from "../../context/AuthContext";


const HomePage = () => {
  const [eventos, setEventos] = useState([]);
  const [nextEventsLogado, setNextEventsLogado] = useState([]);
  const [nextEvents, setNextEvents] = useState([]);
  const [pastEvents, setPastEvents] = useState([]);
  const [notifyUser, setNotifyUser] = useState(); //Componente Notification

  const { userData } = useContext(UserContext);

  // roda somente na inicialização do componente
  useEffect(() => {
    getNextEvents(); //chama a função
    getPastEvents();
    getNextEventsLogado();
  }, []);

  const token = JSON.parse(localStorage.getItem('token'));
  console.log(userData.role)
  const verificaPresenca = (arrAllEvents, eventsUser) => {

    for (let x = 0; x < arrAllEvents.length; x++) {
      //para cada evento principal
      arrAllEvents[x].situacao = false;
      arrAllEvents[x].botao = "Conectar";
      for (let i = 0; i < eventsUser.length; i++) {
        //procurar a correspondência em minhas presenças
        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencasEvento = eventsUser[i].idPresencasEvento;
          arrAllEvents[x].botao = "Desconectar";
          break; //paro de procurar para o evento principal atual
        } else {
          arrAllEvents[x].situacao = false;
          arrAllEvents[x].botao = "Conectar";
        }
      }
      //console.log("Verifica prewsença = ", arrAllEvents[x])
    }
    //retorna todos os eventos marcados com a presença do usuário
    return arrAllEvents;
  };

  async function getNextEventsLogado() {
    try {
      //debugger
      //console.log("Dentro do nextEvents = " ,token.userId)

      
      const todosEventos = await api.get(nextEventResource);
      const meusEventos = await api.get(
        `${myEventsResource}/${token.userId}`
      );
      //debugger
      const eventosMarcados = verificaPresenca(
        todosEventos.data,
        meusEventos.data
      );

      console.log("eventos marcados  = ", eventosMarcados);
      setNextEventsLogado(eventosMarcados);


    } catch (error) {
      console.log("não trouxe os próximos eventos, verifique lá!");

    }
  }

  async function getNextEvents(){
    const promise = await api.get(nextEventResource);
      const dados = await promise.data;
      // console.log(dados);
      setNextEvents(dados);
  }

  async function handleConnect(eventId, idUsuario, confirmacao, presencaId = null,) {
    console.log(eventId, idUsuario, confirmacao, presencaId)
    if (confirmacao === false) {
      try {
        //connect
        const promise = await api.post(presencesEventResource, {
          situacao: true,
          idUsuario: idUsuario,
          idEvento: eventId,
        });
        if (promise.status === 201) {
          getNextEventsLogado()
          alert("Presença confirmada, parabéns");
        }
      } catch (error) { }
      return;
    }
    // unconnect - aqui seria o else
    try {
      const unconnected = await api.delete(
        `${presencesEventResource}/${presencaId}`
      );
      if (unconnected.status === 204) {
        getNextEventsLogado()
        alert("Desconectado do evento");
      }
    } catch (error) {
      console.log("Erro ao desconecar o usuário do evento");
      console.log(error);
    }
  }

  async function getPastEvents() {
    try {
      const promise = await api.get(pastEentResource);
      const dados = await promise.data;
      // console.log(dados);
      setPastEvents(dados); //atualiza o state

    } catch (error) {
      console.log("não trouxe os próximos eventos, verifique lá!");
      // setNotifyUser({
      //   titleNote: "Erro",
      //   textNote: `Não foi possível carregar os próximos eventos. Verifique a sua conexão com a internet`,
      //   imgIcon: "danger",
      //   imgAlt:
      //   "Imagem de ilustração de erro. Rapaz segurando um balão com símbolo x.",
      //   showMessage: true,
      // });
    }
  }



  return (

    <MainContent>
      {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}
      <Banner />

      {/* PRÓXIMOS EVENTOS */}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            {
            userData.role === "Administrador" || userData.role === "Comum" ?
            nextEventsLogado.map((e) => {
              //console.log(e)
              return (
                <NextEvent
                  key={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvent={e.idEvento}
                  situacao={e.situacao}
                  presencaId={e.idPresencasEvento}
                  idUsuario={token.userId}
                  fnConnect={handleConnect}
                  nomeBotao={e.botao}
                />                
              );
            }):
            nextEvents.map((e) => {
              console.log(e)
              return (
                <NextEvent
                  key={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvent={e.idEvento}                  
                  //fnConnect={handleConnect}
                  nomeBotao={e.botao}
                />                
              );
            })            
            }
          </div>
        </Container>
      </section>

      <section className="anterio-eventos">
        <Container>
          <Title titleText={"Eventos anteriores"} />

          <div className="events-box">
            {pastEvents.map((e) => {
              return (
                <PastEvent
                  key={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvent={e.idEvento}
                  buttonLink={`/detalhes-evento/${e.idEvento}`}
                  nomeBotao="Visualizar"
                />
              );
            })}
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
