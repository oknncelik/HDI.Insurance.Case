import { Component, useState } from 'react'
import Container from 'react-bootstrap/Container';
import axios from 'axios';
import ContractTable from '../components/contracts/ContractTable';
import ContractForm from '../components/contracts/ContractForm';
import ProductTable from '../components/products/ProductTable';
import ProductForm from '../components/products/ProductForm';
import PartnerTable from '../components/partners/PartnerTable';
import PartnerForm  from '../components/partners/PartnerForm';
import Button from 'react-bootstrap/Button';
import HDIModal from '../components/base/HDIModal';

function Contracts() {
    const [contractModal, setContractModal] = useState(false);
    const [productModal, setProductModal] = useState(false);
    const [partnerModal, setPartnerModal] = useState(false);
    const [productAddModal, setProductAddModal] = useState(false);
    const [partnerAddModal, setPartnerAddModal] = useState(false);

    return (
        <>
            <div className="container">
                <br />
                <h1>Anlaşmalar</h1>
                <br />
                <div className='contract-operation'>
                    <div className="right">
                        <Button className='m-l-5' variant="success" onClick={() => setContractModal(true)}>Yeni Anlaşma</Button>{''}
                        <Button className='m-l-5' variant="warning" onClick={() => setProductModal(true)}>Ürünler/Hizmetler</Button>{''}
                        <Button className='m-l-5' variant="primary" onClick={() => setPartnerModal(true)}>Partnerler</Button>{' '}
                    </div>
                </div>
                <ContractTable key={ contractModal } />
            </div>

            <HDIModal open={contractModal} title="Yeni Anlaşma Ekle">
                <div className="w-750">
                    <div className="modal-content ">
                        <ContractForm/>
                    </div>                   
                    <div className="modal-bottom">
                        <div className="right10">
                            <Button className='m-l-5' variant="danger" onClick={() => setContractModal(false)}>Kapat</Button>{''}
                        </div>
                    </div>
                </div>
            </HDIModal>

            <HDIModal open={productModal} title="Ürünler/Hizmetler">
                <div className="w-750">
                    <div className="modal-content ">
                        <div className='contract-operation'>
                            <div className="right">
                                <Button className='m-l-5' variant="success" onClick={() => setProductAddModal(true)}>Yeni Ürün/Hizmet</Button>{''}
                            </div>
                        </div>
                        <ProductTable key={productAddModal} />
                    </div>
                    <div className="modal-bottom">
                        <div className="right10">
                            <Button className='m-l-5' variant="danger" onClick={() => setProductModal(false)}>Kapat</Button>{''}
                        </div>
                    </div>
                </div>
            </HDIModal>

            <HDIModal open={productAddModal} title="Ürün/Hizmet Ekle">
                <div className="w-650 ztop">
                    <div className="modal-content ">
                        <ProductForm/>
                    </div>
                    <div className="modal-bottom">
                        <div className="right10">
                            <Button className='m-l-5' variant="danger" onClick={() => setProductAddModal(false)}>Kapat</Button>{''}
                        </div>
                    </div>
                </div>
            </HDIModal>

            <HDIModal open={partnerModal}  title="Partnerler">
                <div className="w-750">
                    <div className="modal-content ">
                        <div className='contract-operation'>
                            <div className="right">
                                <Button className='m-l-5' variant="success" onClick={() => setPartnerAddModal(true)}>Yeni Partner</Button>{''}
                            </div>
                        </div>
                        <PartnerTable key={partnerAddModal} />
                    </div>
                    <div className="modal-bottom">
                        <div className="right10">
                            <Button className='m-l-5' variant="danger" onClick={() => setPartnerModal(false)}>Kapat</Button>{''}
                        </div>
                    </div>
                </div>
            </HDIModal>

            <HDIModal open={partnerAddModal} title="Partner Ekle">
                <div className="w-650 ztop">
                    <div className="modal-content ">
                        <PartnerForm />
                    </div>
                    <div className="modal-bottom">
                        <div className="right10">
                            <Button className='m-l-5' variant="danger" onClick={() => setPartnerAddModal(false)}>Kapat</Button>{''}
                        </div>
                    </div>
                </div>
            </HDIModal>
        </>
    )
}
export default Contracts
