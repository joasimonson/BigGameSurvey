import React, { useEffect, useState } from 'react';

import Pagination from './Pagination';
import Filters from '../../components/Filters';

import api from '../../services/api';
import { formatDatetime } from '../../helpers/Datetime';

import { RecordsResponse } from './types';

import './styles.css';

const Records = () => {
    const [ recordsResponse, setRecordsResponse ] = useState<RecordsResponse>();
    const [ activePage, setActivePage ] = useState(1);

    useEffect(() => {
        async function searchRecords() {
            const response = await api.get(`records?page=${activePage}`);
            setRecordsResponse(response.data);
        }

        searchRecords();
    }, [activePage]);

    function handlePageChange(index: number) {
        setActivePage(index);
    }

    return (
        <div className="page-container">
            <Filters link="/charts" linkText="VER GRÁFICO" />
            <table className="records-table" cellPadding="0" cellSpacing="0">
                <thead>
                    <tr>
                        <th>INSTANTE</th>
                        <th>NOME</th>
                        <th>IDADE</th>
                        <th>PLATAFORMA</th>
                        <th>GÊNERO</th>
                        <th>TÍTULO DO GAME</th>
                    </tr>
                </thead>
                <tbody>
                    {recordsResponse?.collection.map(rec => (
                        <tr key={rec.id}>
                            <td>{formatDatetime(rec.insertedAt)}</td>
                            <td>{rec.name}</td>
                            <td>{rec.age}</td>
                            <td className="text-secondary">{rec.game.platform}</td>
                            <td>{rec.genre.name}</td>
                            <td className="text-primary">{rec.game.title}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <Pagination
                activePage={activePage}
                goToPage={handlePageChange}
                totalPages={recordsResponse?.pagination.totalPages}
            />
        </div>
    )
};

export default Records;