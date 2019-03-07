import { Component, OnInit, TemplateRef } from '@angular/core';
import { EscolaService } from '../_services/escola.service';
import { Escola } from '../_models/Escola';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { template } from '@angular/core/src/render3';


@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.css'],
})
export class EscolasComponent implements OnInit {

   escolasFiltradas: Escola[];  
   escolas: Escola[];
   escola: Escola;
   registerForm: FormGroup; 
   modoSalvar = 'post'; 
   bodyDeletarEscola = '';  

  _filtroLista = ''; 

  constructor(
    private escolaService: EscolaService,
    private modalService: BsModalService,
    private fb: FormBuilder
    ) { }

  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value; 
    this.escolasFiltradas = this.filtroLista ? this.filtrarEscolas(this.filtroLista) : this.escolas;  
  }


  editarEscola(escola: Escola, template: any){
    this.modoSalvar = 'put'; 
    this.openModal(template);  
    this.escola = escola;  
    this.registerForm.patchValue(escola);  

  }
  novaEscola(template: any){
    this.modoSalvar = 'post';
    this.openModal(template);  
  }
  excluirEscola(escola: Escola, template: any){
    this.openModal(template);  
    this.escola = escola; 
    this.bodyDeletarEscola = `Tem certeza que deseja excluir a Escola: ${escola.nome}, Código: ${escola.id}`;
  }
  confirmeDelete(template: any){
    this.escolaService.deleteEscola(this.escola.id).subscribe(
      () => {
      template.hide();
      this.getEscolas();  
    }, error =>{
      console.log(error);
    }
  );

  }
  openModal(template: any){
    this.registerForm.reset();
    template.show(); 
  }
  

  ngOnInit() { 
    this.validation(); 
    this.getEscolas();  
  }
  filtrarEscolas(filtrarPor: string): Escola[] {
    filtrarPor = filtrarPor.toLocaleLowerCase(); 
    return this.escolas.filter(
      escola => escola.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  validation(){
    this.registerForm = this.fb.group({
      nome: ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      cidade: ['', Validators.required],
      bairro: ['', Validators.required],
      rua: ['', Validators.required],
      diretor: ['', Validators.required], 
    });
  }
  salvarAlteracao(template: any){
    if(this.registerForm.valid){
      if(this.modoSalvar === 'post'){
        this.escola = Object.assign({}, this.registerForm.value); 
        this.escolaService.postEscola(this.escola).subscribe(
            (novaEscola: Escola) => {
            template.hide();
            this.getEscolas();  
          }, error =>{
            console.log(error);
          }
        );
      }else{
        this.escola = Object.assign({id: this.escola.id}, this.registerForm.value); 
        this.escolaService.putEscola(this.escola).subscribe(
            () => {     
            template.hide();
            this.getEscolas();  
          }, error =>{
            console.log(error);
          }
        );

      }
    }
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
