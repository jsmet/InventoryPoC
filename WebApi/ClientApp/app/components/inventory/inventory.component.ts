
import {
    Component,
    Injectable,
    OnInit
} from '@angular/core';

import { NgIf } from '@angular/common';

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { InventoryService } from '../services/inventory.service';

@Component({
    selector: 'inventory',
    templateUrl: './inventory.component.html',
    styleUrls: ['./inventory.component.css'],
    providers: [InventoryService]
})
export class InventoryComponent implements OnInit {

    public test = "";

    public products: Product; 
    public productTypes: ProductTypes;
    public items: Item;
    public errors: string;

    constructor(private inventoryService: InventoryService) { }

    ngOnInit(): void {
        this.inventoryService.getProducts()
            .subscribe(products => {
                this.products = products
            }, error => this.errors = <any>error
        );

        this.inventoryService.getProductTypes()
            .subscribe(productTypes => {
                this.productTypes = productTypes
            }, error => this.errors = <any>error
        );
    }

    public getItems(name: string) {
        this.test = name;
        this.inventoryService.getItems(name)
            .subscribe(items => {
                this.items = items
            }, error => <any>error
        );
    }
}

interface Product {
    name: string;
    description: string;
}

interface ProductTypes {
    name: string;
    icon: string;
}

interface Item {
    name: string;
    description: string;
    cost: string;
    quantityOnHand: number;
    expirationDate: string;
}