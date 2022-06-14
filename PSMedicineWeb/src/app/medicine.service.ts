import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {

  private basePath='https://localhost:44329/api/MedicineStore';
  constructor(private http: HttpClient) {}

    public getMedicines(): Observable<any>{

      return this.http.get(this.basePath+"/GetMedicine");
    }

   }

