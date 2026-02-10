import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Equipment, CreateEquipment } from '../models/equipment.model';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class EquipmentService {
  private baseUrl = `${environment.apiBaseUrl}/equipment`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Equipment[]> {
    return this.http.get<Equipment[]>(this.baseUrl);
  }

  create(dto: CreateEquipment): Observable<Equipment> {
    return this.http.post<Equipment>(this.baseUrl, dto);
  }

  update(id: number, dto: CreateEquipment): Observable<Equipment> {
    return this.http.put<Equipment>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
