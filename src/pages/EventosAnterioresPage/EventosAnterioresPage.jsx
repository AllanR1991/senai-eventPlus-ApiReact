import React from 'react';
import Container from '../../components/Container/Container';
import MainContent from '../../components/MainContent/MainContent';
import Title from '../../components/Title/Title';
import Table from '../EventosPage/TableEv/TableEv';
import "./EventosAnterioresPage.css"
const EventosAnterioresPage = () => {
    return (
        <>
        <MainContent>
            <Container>
                <Title titleText={"Eventos anteriores"} additionalClass="custom-title"/>
            </Container>
        </MainContent>
        </>
    );
};

export default EventosAnterioresPage;