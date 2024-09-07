import axios from "axios";
import { baseUrl } from "../constants/url.const";

const httpModule = axios.create({
  baseURL: baseUrl,
});

export default httpModule;