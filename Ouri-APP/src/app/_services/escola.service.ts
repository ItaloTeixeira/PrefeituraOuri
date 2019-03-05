import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Escola } from '../_models/Escola';
import { EscolasComponent } from '../escolas/escolas.component';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {
  baseURL = 'http://localhost:5000/api/escola';
  

 constructor(private http: HttpClient){}

 getAllEscola(): Observable<Escola[]>{
   return this.http.get<Escola[]>(this.baseURL);
 }
 getEscolaByName(nome: string): Observable<Escola[]>{
   return this.http.get<Escola[]>(`${this.baseURL}/getByName/${nome}`);
 }
 getEscolaById(id: number): Observable<Escola>{
   return this.http.get<Escola>(`${this.baseURL}/${id}`);
 }
postEscola(escola: Escola){
  return this.http.post(this.baseURL, escola);
}
putEscola(escola: Escola){
  return this.http.put(`${this.baseURL}/${escola.id}`, escola);
}
deleteEscola(id: number){
    return this.http.delete(`${this.baseURL}/${id}`);
}
}
