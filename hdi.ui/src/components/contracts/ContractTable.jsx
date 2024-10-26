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
        name: 'Partner Adı',
        selector: row => row.Partner.Name,
        sortable: true
    },
    {
        name: 'Ürün/Hizmet Adı',
        selector: row => row.Product.Name,
        sortable: true
    },
    {
        name: 'İş Adedi',
        selector: row => row.Count,
        sortable: true
    },
    {
        name: 'Birim Fiyat',
        selector: row => row.Price,
        sortable: true
    },
    {
        name: 'Başlangıç Tarihi',
        cell: row => new Date(row.StartDate).toLocaleDateString(),
        selector: row => row.StartDate,
        sortable: true
    },
    {
        name: 'Bitiş Tarihi',
        cell: row => new Date(row.EndDate).toLocaleDateString(),
        selector: row => row.EndDate,
        sortable: true
    },
];

function ContractList() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        setLoading(true);
        axios.get(packageJson.serviceBaseURL + "api/contract/getlist")
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
        <div>
            {
                data ? <DataTable columns={columns} data={data} /> : <h1>Veri Bulunamadı !</h1>
            }
        </div>
    );
}

export default ContractList;
