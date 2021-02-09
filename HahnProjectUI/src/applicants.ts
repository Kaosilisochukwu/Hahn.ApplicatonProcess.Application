import { IApplicants, ApplicantService } from './applicants-service';
import { autoinject } from 'aurelia-framework'
import {HttpClient, json} from 'aurelia-fetch-client';

@autoinject
export class Applicants{
  
  applicants: Array<IApplicants>
  controller: any
  http: HttpClient;
constructor(http:HttpClient, private services:ApplicantService){
  this.http = http;
  this.getApplicants();
  //this.applicants = [];
  
}

  getApplicants():any {
    const config = {
      headers: {
        "Content-Type":"application/json"
      },
      method: "get",
    }
    
   this.http.fetch("http://localhost:5000/api/applicant",config).then(res=> res.json()).then(data=>{
     this.applicants = [...data.data]
     console.log(this.applicants)
   } );   
  }
}
