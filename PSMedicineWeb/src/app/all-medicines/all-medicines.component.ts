import { Component, OnInit } from '@angular/core';
import { MedicineService } from '../medicine.service';

@Component({
  selector: 'app-all-medicines',
  templateUrl: './all-medicines.component.html',
  styleUrls: ['./all-medicines.component.scss']
})
export class AllMedicinesComponent implements OnInit {

  public medicines: any;
  constructor(private service: MedicineService) { }

  ngOnInit(): void {
    this.getMedicines();
  }

  private getMedicines(): void
  {
    this.service.getMedicines().subscribe(result =>{

      this.medicines= result.data;
    });
  }

}
