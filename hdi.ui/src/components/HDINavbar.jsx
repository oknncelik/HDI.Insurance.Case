﻿import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

function HDINavbar() {
    return (
        <>
            <Navbar bg="light" data-bs-theme="light">
                <Container>
                    <Navbar.Brand href="/">HDI</Navbar.Brand>
                    <Nav className="me-auto">
                        <Nav.Link href="/contracts">Anlaşmalar</Nav.Link>
                        <Nav.Link href="/works">İşler</Nav.Link>
                        <Nav.Link href="/metrics">İstatistikler</Nav.Link>
                    </Nav>
                </Container>
            </Navbar>
        </>
    );
}

export default HDINavbar;