import React, { useContext,useEffect, useState } from 'react';
import Title from '../../components/Title/Title';
import Container from '../../components/Container/Container';
import MainContent from '../../components/MainContent/MainContent';
import './DetalheEvento.css'
import Table from "./TableDe/TableDe";
import { useParams } from 'react-router-dom';
import { UserContext } from "../../context/AuthContext";
import api, {
    eventsResource,
    myEventsResource,
    presencesEventResource,
    commentaryEventResource,
    commentaryEventIAResource,
    eventsTypeResource,
  } from "../../Services/Service";

const DetalhesEventoPage = () => {

    const { idEvento } = useParams();

    const [evento, setEvento] = useState([])
    const [data, setData] = useState([]);
    const [descricao, setDescricao] = useState([]);
    const [tipo, setTipo] = useState([]);
    const [idTipoEvento, setIdTipoEvento]= useState([]);
    const [comentarios, setComentario] = useState([]);
    const token = JSON.parse(localStorage.getItem('token'));

    const { userData } = useContext(UserContext);

    //console.log(token);
    useEffect(() => {
        listarComentario();
      }, []); //

    async function listarComentario(){
        
        const getEvento = await api.get(`${eventsResource}/${idEvento}`)
        console.log(getEvento);
        const listaDeComentario = await api.get(commentaryEventResource);

        const comentariosOfensasFiltrados = await listaDeComentario.data.filter(
            (comm) => comm.idEvento === idEvento && comm.exibe === true
        );
        
        const comentariosFiltrados = await listaDeComentario.data.filter(
            (comm) => comm.idEvento === idEvento
        );

        setEvento(getEvento.data.nomeEvento);
        setDescricao(getEvento.data.descricao);         
        setData(getEvento.data.dataEvento);
        //setIdTipoEvento(getEvento.data.idTipoEvento);
        const idTeste = getEvento.data.idTipoEvento
        const getTipoEvento = await api.get(`${eventsTypeResource}/${idTeste}`)


        console.log(getTipoEvento.data.tipoEvento)

        setTipo(getTipoEvento.data.tipoEvento);

        //console.log("Tipo evento =", tipoEventoFilter)
        userData.role == "Administrador" ?
            setComentario(comentariosFiltrados):
            setComentario(comentariosOfensasFiltrados);
        
    }
    return (
        <>
            <MainContent>
                <section>
                    <Container>
                        <div>
                            <Title titleText={"Detalhes Evento"} />
                            <Table
                                evento={evento}
                                descricao={descricao}
                                data={data}
                                tipoEvento={tipo}
                                comentarios={comentarios}
                            />

                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default DetalhesEventoPage;