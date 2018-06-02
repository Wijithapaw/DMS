import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { MessageService } from '../../core/services/message.service';

@Injectable()
export class ErrorsHandler implements ErrorHandler {

    constructor(private injector: Injector) {
    }

    handleError(error: Error | HttpErrorResponse) {
        const router = this.injector.get(Router);
        const messageService = this.injector.get(MessageService);
        var errorMsg = '';
        if (error instanceof HttpErrorResponse) {
            // Server or connection error happened
            if (!navigator.onLine) { // Handle offline error
                errorMsg = 'Error in internet connection';
            } else { //Server side errors
                if (error.status == 401) { //Unauthorize Access
                    localStorage.removeItem("authToken");
                    sessionStorage.removeItem("authToken");

                    let link = ['/login', { returnUrl: router.url }];
                    router.navigate(link);

                    errorMsg = 'Have you forgotton to login?';

                } else if (error.status == 403) { // Forbidden access
                    localStorage.removeItem("authToken");
                    sessionStorage.removeItem("authToken");

                    let link = ['/login'];
                    router.navigate(link);

                    errorMsg = 'You are in wrong place';
                }
                else { //This could be custom error. Show Error Message                    
                    errorMsg = error.error.message;
                }
            }
        } else {
            // Handle Client Error (Angular Error, ReferenceError...)     
            errorMsg = 'Unhanled error in Angular App';
        }
        // Log the error anyway
        messageService.showInfo(errorMsg);
        console.log(messageService.msgs);
        console.error('It happens: ', error);
    }
}