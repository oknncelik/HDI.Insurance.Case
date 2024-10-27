import React, { useState, useEffect } from 'react';
import axios from 'axios';
import packageJson from '../../../package.json';
import DataTable from 'react-data-table-component';

const columns = [
    {
        name: '#',
        selector: row => row.Id,
        sortable: true
    },
    {
        name: 'Name',
        selector: row => row.Name,
        sortable: true
    },
];

function WorkTable() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        setLoading(true);
        axios.get(packageJson.serviceBaseURL + "api/work/getlist")
            .then(response => {
                setData(response.data.Data);
                setLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <div>Yükleniyor....</div>;
    }

    if (error) {
        return <p>Hata: {error}</p>;
    }

    return (
        <div className="scroll">
            {
                data && data.length > 0 ? <DataTable columns={columns} data={data} /> : <p>Veri Bulunamadı !</p>
            }
        </div>
    );
}

export default WorkTable;
