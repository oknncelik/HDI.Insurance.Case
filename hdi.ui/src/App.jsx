import HDINavbar from "../src/components/HDINavbar"
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Contracts from '../src/pages/Contracts';
import Works from '../src/pages/Works';
import Metrics from '../src/pages/Metrics';
import './app.css';
import Button from 'react-bootstrap/Button';

function App() {
  return (
      <>
       <HDINavbar />
       <br/>
       <div className="container">
            <BrowserRouter>
                <Routes>
                      <Route index element={<Contracts />} />
                      <Route path="/contracts" element={<Contracts />} />
                      <Route path="/works" element={<Works />} />
                      <Route path="/metrics" element={<Metrics />} />
                </Routes>
            </BrowserRouter>
       </div>
    </>
  )
}

export default App
