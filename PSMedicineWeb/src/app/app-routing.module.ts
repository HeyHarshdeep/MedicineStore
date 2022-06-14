import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllMedicinesComponent } from './all-medicines/all-medicines.component';

const routes: Routes = [{
path:'medicines',component: AllMedicinesComponent  

}];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
