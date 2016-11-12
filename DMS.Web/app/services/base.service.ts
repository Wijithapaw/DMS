import {Injectable} from '@angular/core';

@Injectable()
export class BaseService {
    handleError(error: any): Promise<any> {
        console.error('Error Occured', error);
        return Promise.reject(error.message || error);
    }
}