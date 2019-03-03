import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.css']
})
export class EscolasComponent implements OnInit {

  escolas: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEscolas();  
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
