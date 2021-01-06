import { Photo } from './photo';
export interface User {
    id: number;
        userName: string;
       Gender: string ;
       age: number;
        knownAs: string;
        CreatedDate: Date;
        LastActivate: Date;
        Introduction: string;
        LookingFor: string;
        Interests: string;
        city: string;
        Countery: string;
        photoUrl: string;
        Photos?: Photo[];
}
