import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.css']
})
export class EscolasComponent implements OnInit {

  _filtroLista: string; 
  //encapsulament
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value; 
    this.escolasFiltradas = this.filtroLista ? this.filtrarEscolas(this.filtroLista) : this.escolas;  
  }
  escolasFiltradas: any = [];  
  escolas: any = [];
  constructor(private http: HttpClient) { }

  ngOnInit() { 
    this.getEscolas();  
  }
  filtrarEscolas(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase(); 
    return this.escolas.filter(
      escola => escola.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  getEscolas(){
    this.http.get('http://localhost:5000/ouri/values').subscribe(response => {
    this.escolas = response;
    }, error =>{
      console.log(error);  
    }
    );
  }

}
