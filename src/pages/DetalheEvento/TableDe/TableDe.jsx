import React from 'react';
import './TableDe.css'
import "react-tooltip/dist/react-tooltip.css";
import { dateFormateDbToView } from "../../../Utils/stringFunctions";

const TableDe = ({ evento, descricao, data, comentarios, tipoEvento }) => {
    return (
        <table className="table-data text-color">
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">
                        Evento
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Descrição
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Tipo Evento
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Data
                    </th>
                </tr>

                <tr
                    className='tbal-data__head-row tbal-data__head-row--red-color'
                >
                    <th className="table-data__head-title table-data__head-title--big font-color">{evento}</th>
                    <th className="table-data__head-title table-data__head-title--big font-color" >{descricao}</th>
                    <th className="table-data__head-title table-data__head-title--big font-color">{tipoEvento}</th>
                    <th className="table-data__head-title table-data__head-title--big font-color">
                        {/* {data} */}
                        {dateFormateDbToView(data)}
                    </th>
                </tr>
            </thead>

            <tbody>
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">
                        Comentário
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Usuário
                    </th>

                </tr>
                {

                    comentarios.map((c) => {
                        return (
                            <tr className="tbal-data__head-row" key={Math.random()}>
                                <td>{c.descricao}</td>
                                <td className="table-data__head-title table-data__head-title--big">{c.usuario.nome }</td>
                            </tr>
                        )

                    })}
            </tbody>



        </table>
    );
};

export default TableDe;