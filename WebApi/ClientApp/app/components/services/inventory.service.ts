
import { Injectable } from '@angular/core';
import { Headers, RequestOptions, Response, HttpModule } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { HttpInterceptor } from './http-interceptor';

@Injectable()
export class InventoryService {

    private readonly baseProductURL = "api/Product"

    private readonly defaultHeaders = new Headers({
        'Content-Type': 'application/json',
        'Cache-control': 'no-cache',
        'Expires': '0',
        'Pragma': 'no-cache',
    });   

    constructor(private http: HttpInterceptor) { }   


    getProducts(): Observable<any> {
        return this.http.get(`${this.baseProductURL}/GetProducts`,
            new RequestOptions({
                headers: this.defaultHeaders,
            }))
            .map((res: Response) => {
                const body = res.json();
                return body || {};
            });
    }

    getProductTypes(): Observable<any> {
        return this.http.get(`${this.baseProductURL}/GetProductTypes`,
            new RequestOptions({
                headers: this.defaultHeaders,
            }))
            .map((res: Response) => {
                const body = res.json();
                return body || {};
            });
    }

    getItems(productName: string): Observable<any> {
        return this.http.get(`${this.baseProductURL}/GetItems`,
            new RequestOptions({
                headers: this.defaultHeaders,
                params: {
                    productName
                },
            }))
            .map((res: Response) => {
                const body = res.json();
                return body || {};
            });
    }
}