import { Turma } from './Turma';  
import { Escola } from './Escola';  
export interface Professor {

    id: number;  
    nome: string; 
    email: string;  
    turmas: Turma[];
    professoresEscolas: Escola[];    
}
