import axios from "axios";

const baseUrl = "https://localhost:5001/api";


export async function get<T>(url: string, params: {[key: string]: any }): Promise<T> {

    try
    {
        const result = await axios.get<T>(`${baseUrl}/${url}`, {
            params: params
        });
        return result.data;
    } catch (error) {
        console.error(error);
        return Promise.reject(error);
    }
}