export class ApplicantService{
  
}
export interface IRegister{
  name:string,
  familyName:string,
  emailAddress:string,
  age:number,
  address: string,
  countryOfOrigin:string,
  hired:boolean
}

export interface IApplicants{
  id: number,
  name:string,
  familyName:string,
  emailAddress:string,
  age:number,
  address: string,
  countryOfOrigin:string,
  hired:boolean
}

