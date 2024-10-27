import React, { useState, useEffect } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import packageJson from '../../../package.json';
import axios from 'axios';

function PartnerForm() {
    const [message, setMessage] = useState("");

    const savePartner = async (e) => {
        e.preventDefault();
        try {
            setMessage("Kaydediliyor...");
            let request = {
                Name: e.target.elements.productName.value
            }

            if (!request.Name) {
                setMessage("Lütfen partner adı giriniz !");
                return;
            }

            const response = await axios.post(packageJson.serviceBaseURL + "api/partner/add", request);
            if (response.data.IsSuccess) {
                setMessage("Kaydedildi.");
            }
        } catch (error) {
            setMessage('Hata:', error);
        }
    };

    return (
        <Form className="p10" onSubmit={savePartner}>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label>Partner Adı</Form.Label>
                <Form.Control type="text" name="productName" placeholder="Partner Adı Giriniz.." />
            </Form.Group>
            <div class="float-end">
                {message}
                <Button type="submit" className='m-l-5' variant="success" >Kaydet</Button>{''}
            </div>

        </Form>
    );
}

export default PartnerForm;