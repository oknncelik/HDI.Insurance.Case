import React, { useState, useEffect } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import packageJson from '../../../package.json';
import axios from 'axios';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Select from 'react-select';

function ContractForm() {
    const [message, setMessage] = useState("");
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    const [partnerLookup, setPartnerLookup] = useState([]);
    const [productLookup, setProductLookup] = useState([]);
    const [partner, setPartner] = useState(0);
    const [product, setProduct] = useState(0);

    const [request, setRequest] = useState({
        PartnerId : 0,
        ProductId : 0,
        Count :0,
        Price :0,
        StartDate: new Date(),
        EndDate : new Date()
    });

    const saveContract = async (e) => {
        e.preventDefault();
        try {
            setMessage("Kaydediliyor...");
            let request = {
                PartnerId: e.target.elements.partnerId.value,
                ProductId: e.target.elements.productId.value,
                Count: e.target.elements.count.value,
                Price: e.target.elements.price.value,
                StartDate: startDate,
                EndDate: endDate
            }

            if (!request.PartnerId ||
                !request.ProductId ||
                !request.Count ||
                !request.Price ||
                !request.StartDate ||
                !request.EndDate) {
                setMessage("Lütfen tüm alanları doldurunuz !");
            }

            const response = await axios.post(packageJson.serviceBaseURL + "api/contract/add", request);
            if (response.data.IsSuccess) {
                setMessage("Kaydedildi.");
            }
        } catch (error) {
            setMessage('Hata:', error);
        }
    };

    useEffect(() => {
        axios.get(packageJson.serviceBaseURL + "api/partner/getlist")
            .then(response => {
                setPartnerLookup(response.data.Data.map(item => ({ value: item.Id, label: item.Name })));
            })
            .catch(err => {

            });

        axios.get(packageJson.serviceBaseURL + "api/product/getlist")
            .then(response => {
                setProductLookup(response.data.Data.map(item => ({ value: item.Id, label: item.Name })));
            })
            .catch(err => {

            });
    }, []);

    return (
        <Form className="p10" onSubmit={saveContract}>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label>Partner</Form.Label>
                <Select
                    options={partnerLookup}
                    placeholder="Partner Seçiniz.."
                    isClearable
                    isSearchable
                    name ="partnerId"
                    onSelect={(val) => setPartner(val)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label>Ürün/Hizmet</Form.Label>
                <Select
                    options={productLookup}
                    placeholder="Ürün/Hizmet Seçiniz.."
                    isClearable
                    isSearchable
                    name="productId"
                    onSelect={(val) => setProduct(val)}
                />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label>İş Adedi</Form.Label>
                <Form.Control type="text" name="count" placeholder="İş Adedi Giriniz.." />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label>Fiyat</Form.Label>
                <Form.Control type="text" name="price" placeholder="Fiyat Giriniz.." />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Row>
                    <Col>
                        <Form.Label>Başlangıç Tarihi</Form.Label>
                        <br />
                        <DatePicker className="form-control db" selected={startDate} onChange={date => setStartDate(date)} />
                    </Col>
                    <Col>
                        <Form.Label>Bitiş Tarihi</Form.Label>
                        <br />
                        <DatePicker className="form-control db" selected={endDate} onChange={date => setEndDate(date)} />
                    </Col>
                </Row>
            </Form.Group>
            <div class="float-end">
                {message}
                <Button type="submit" className='m-l-5' variant="success" >Kaydet</Button>{''}
            </div>

        </Form>
    );
}

export default ContractForm;