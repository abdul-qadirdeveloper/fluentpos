import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PosRoutingModule } from './pos-routing.module';
import { MaterialModule } from 'src/app/core/material/material.module';
import { PosComponent } from './pos.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { CustomerSelectionComponent } from './components/customer-selection/customer-selection.component';
import { CustomerInfoComponent } from './components/customer-info/customer-info.component';
import { ProductInfoComponent } from './components/product-info/product-info.component';

import { SharedModule } from 'src/app/core/shared/shared.module';
import { CartComponent } from './components/cart/cart.component';
import { PosToolbarComponent } from './components/pos-toolbar/pos-toolbar.component';
import { TranslateModule } from '@ngx-translate/core';

import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';
import { CatalogSkeletonComponent } from './components/catalog-skeleton/catalog-skeleton.component';

@NgModule({
  declarations: [
    PosComponent,
    CustomerComponent,
    CatalogComponent,
    CustomerSelectionComponent,
    CustomerInfoComponent,
    ProductInfoComponent,
    CartComponent,
    PosToolbarComponent,
    CatalogSkeletonComponent
  ],
  imports: [
    CommonModule,
    PosRoutingModule,
    MaterialModule,
    SharedModule,
    TranslateModule,
    NgxSkeletonLoaderModule
  ]
})
export class PosModule { }
