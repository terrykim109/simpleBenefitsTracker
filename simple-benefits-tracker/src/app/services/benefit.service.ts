// benefits.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Benefit } from '../models/benefit.model'; 

@Injectable({
  providedIn: 'root'
})
export class BenefitsService {
  private apiUrl = `${environment.apiUrl}/benefits`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Benefit[]> {
    return this.http.get<Benefit[]>(this.apiUrl);
  }

  getById(id: number): Observable<Benefit> {
    return this.http.get<Benefit>(`${this.apiUrl}/${id}`);
  }

  create(benefit: Partial<Benefit>): Observable<Benefit> {
    return this.http.post<Benefit>(this.apiUrl, benefit);
  }

  update(id: number, benefit: Partial<Benefit>): Observable<Benefit> {
    return this.http.put<Benefit>(`${this.apiUrl}/${id}`, benefit);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
