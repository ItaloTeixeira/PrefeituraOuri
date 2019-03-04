import { Turma } from './Turma';  
import { Professor } from './Professor';  

export interface Escola {
    id: number;
    nome: string; 
    cidade: string; 
    bairro: string; 
    rua: string; 
    diretor: string; 
    turmas: Turma[];
    professoresescolas: Professor[];

}
