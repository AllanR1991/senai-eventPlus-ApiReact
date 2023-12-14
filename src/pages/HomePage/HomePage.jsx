import React, { useContext,useEffect, useState } from "react";
import "./HomePage.css";

import Banner from "../../components/Banner/Banner";
import MainContent from "../../components/MainContent/MainContent";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import Title from "../../components/Title/Title";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container";
import api from "../../Services/Service";
import Notification from "../../components/Notification/Notification";
import { nextEventResource, pastEentResource, myEventsResource } from "../../Services/Service";
import { UserContext } from "../../context/AuthContext";


const HomePage = () => {
  const [eventos, setEventos] = useState([]);
  const [nextEvents, setNextEvents] = useState([]);
  const [pastEvents, setPastEvents] = useState([]);
  const [notifyUser, setNotifyUser] = useState(); //Componente Notification

  const { userData } = useContext(UserContext);

  // roda somente na inicialização do componente
  useEffect(() => {
    getNextEvents(); //chama a função
    getPastEvents();
  }, []);
  
  const verificaPresenca = (arrAllEvents, eventsUser) => {
          
    for (let x = 0; x < arrAllEvents.length; x++) {
      //para cada evento principal
      for (let i = 0; i < eventsUser.length; i++) {
        //procurar a correspondência em minhas presenças
        if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencasEvento = eventsUser[i].idPresencasEvento;
          break; //paro de procurar para o evento principal atual
        }
      }
    }
    //retorna todos os eventos marcados com a presença do usuário
    return arrAllEvents;
  };
  
  async function getNextEvents() {
    try {
      //debugger
      console.log("Dentro do nextEvents = " ,userData.userId)

      const todosEventos = await api.get(nextEventResource);
      const meusEventos = await api.get(
        `${myEventsResource}/3c06d1ee-e3a2-4597-a843-5610f7c4e664`
      );  
      /*
      ${userData.userId}
      */
      console.log("Meus eventos = ",meusEventos.data);
      console.log("Tamanho meus eventos = ",meusEventos.data.length);
      console.log("todos eventos = ",todosEventos.data);
      console.log("Tamanho de todos eventos = ",todosEventos.data.length);
      const eventosMarcados = verificaPresenca(
        todosEventos.data,
        meusEventos.data
      );
     
      console.log("eventos marcados  = ", eventosMarcados);
      setNextEvents(eventosMarcados);
      
      // const promise = await api.get(nextEventResource);
      // const dados = await promise.data;
      // console.log(dados);
      // setNextEvents(dados); //atualiza o state

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
            {nextEvents.map((e) => {
              return (
                <NextEvent
                  key={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvent={e.idEvento}
                  nomeBotao="Conectar"
                />
              );
            })}
          </div>
        </Container>
      </section>

      <section className="anterio-eventos">
        <Container>
         <Title titleText={"Eventos anteriores"} />

          <div className="events-box">
            {pastEvents.map((e) => {
              return (
                <NextEvent
                  key={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvent={e.idEvento}
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
