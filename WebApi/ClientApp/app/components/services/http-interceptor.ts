
import { Injectable } from '@angular/core';
import { Http, Request, RequestOptions, RequestOptionsArgs, Response, XHRBackend, HttpModule } from '@angular/http';
import { Observable } from 'rxjs/rx';

// operators
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class HttpInterceptor extends Http {

    constructor(
        backend: XHRBackend,
        options: RequestOptions,
        public http: Http,
    ) {
        super(backend, options);
    }

    public request(url: string | Request, options?: RequestOptionsArgs): Observable<Response> {
        return super.request(url, options)
            .catch(this.handleError);
    }

    public handleError = (error: Response) => {
        let errMsg: string;
        if (error instanceof Response) {
            errMsg = `${error.status} - ${error.statusText || ''}`;
        } else {
            errMsg = 'Unknown Server Error.';
        }
        return Observable.throw(error);
    }
}