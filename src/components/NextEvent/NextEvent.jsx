import React from "react";
import "./NextEvent.css";
import api from "../../Services/Service";
import { Tooltip } from "react-tooltip";
import {presencesEventResource} from "../../Services/Service";

// importar a função lá do arquivo stringFunction (destructuring)
import { dateFormatDbToView } from "../../Utils/stringFunctions";

const NextEvent = ({ title,nomeBotao,fnConnect, description, eventDate, idEvent, situacao, presencaId,idUsuario }) => {
  async function conectar(idEvent) {
    // dá pra usar a prop idEvent? testar
    alert(`Chamar o recurso para conectar: ${idEvent}`);
  }

  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>

      <p
        className="event-card__description"
        
        data-tooltip-id={idEvent}
        data-tooltip-content={description}
        data-tooltip-place="top"
      >
        <Tooltip id={idEvent} className="tooltip" />
        {description.substr(0, 15)} ...
      </p>

      <p className="event-card__description">
        {/* aplicar a função pra converter a data */}
        {dateFormatDbToView(eventDate)}
      </p>

      <a
        onClick={() => {
          fnConnect(idEvent,idUsuario,situacao,presencaId);
        }}
        className="event-card__connect-link"
      >
        {nomeBotao}
      </a>

      <p>{situacao}</p>
    </article>
  );
};

export default NextEvent;
