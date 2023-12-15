import React, { useEffect, useState } from 'react';
import Title from '../../components/Title/Title';
import Container from '../../components/Container/Container';
import MainContent from '../../components/MainContent/MainContent';
import './DetalheEvento.css'
import Table from "./TableDe/TableDe";
import { useParams } from 'react-router-dom';

const DetalhesEventoPage = () => {

    const { idEvento } = useParams();

    const [evento, setEvento] = useState([])

    const [comentario, setComentario] = useState([]);

    const [tipo, setTipo] = useState([]);

    

    return (
        <>
            <MainContent>
                <section>
                    <Container>
                        <div>
                            <Title titleText={"Detalhes Evento"} />
                            <Table
                                evento={evento}
                                comentario={comentario}
                                tipo={tipo}
                            />

                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default DetalhesEventoPage;