import packageJson from '../package.json';

const productListURL = packageJson.serviceBaseURL + "api/Product/GetList";

class ServiceURLs extends Component {
    getURL() {
        return packageJson.serviceBaseURL + "api/Product/GetList";
    }
}
export default ServiceURLs
