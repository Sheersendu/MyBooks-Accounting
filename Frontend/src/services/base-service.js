import axios from 'axios';
import Constants from './constants';

const backendRequest = ( path, payload, method = 'GET',headers) => {
    path = Constants.urlPrefix + path;
    const requestConfig = {
        url: path,
        method,
        data: payload,
        timeout: Constants.RequestTimeout,
        headers: {
            'content-type': 'application/json;charset=UTF-8',
			'Access-Control-Allow-Origin' : 'https://localhost:7294',
            accept: 'application/json',
            ...headers
        },
        responseType: 'json'
    };
    return new Promise((resolve, reject) => {
		axios
			.request(requestConfig)
			.then((response) => {
				resolve(response.data);
			})
			.catch((error) => {
				if (error.response) {
					if (error.response.status === Constants.HttpStatusCodeConflict) {
						reject(error);
					} else {
						reject(error.response.data);
					}
				}
				reject(error);
			});
	});
}
export { backendRequest };