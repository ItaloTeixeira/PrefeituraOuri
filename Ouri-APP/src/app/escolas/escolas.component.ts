import { Component, OnInit, TemplateRef } from '@angular/core';
import { EscolaService } from '../_services/escola.service';
import { Escola } from '../_models/Escola';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';


@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.css'],
  providers: [EscolaService]

})
export class EscolasComponent implements OnInit {

   escolasFiltradas: any = [];  
   escolas: Escola[];
   modalRef: BsModalRef; 
  _filtroLista = ''; 

  constructor(
    private escolaService: EscolaService,
    private modalService: BsModalService
    ) { }

  //encapsulament
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value; 
    this.escolasFiltradas = this.filtroLista ? this.filtrarEscolas(this.filtroLista) : this.escolas;  
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template); 
  }
  

  ngOnInit() { 
    this.getEscolas();  
  }
  filtrarEscolas(filtrarPor: string): Escola[] {
    filtrarPor = filtrarPor.toLocaleLowerCase(); 
    return this.escolas.filter(
      escola => escola.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  getEscolas(){
    this.escolaService.getAllEscola().subscribe(
    (_escolas: Escola[]) => {this.escolas = _escolas;
      this.escolasFiltradas = this.escolas;
      console.log(_escolas); 

    }, error =>{
      console.log(error);  
    }
    );
  }

}
