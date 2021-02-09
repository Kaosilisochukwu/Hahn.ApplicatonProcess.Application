import { IApplicants } from './applicants-service';
import { autoinject } from 'aurelia-framework'
import {HttpClient, json} from 'aurelia-fetch-client';

@autoinject
export class Details{
  
  id;
  applicant: IApplicants
  controller: any
  http: HttpClient;
constructor(http:HttpClient){
  this.http = http;
  //this.getApplicants();
  
}

activate(params) {
  this.id = params.id
  console.log(this.id)
  const config = {
    headers: {
      "Content-Type":"application/json"
    },
    method: "get",
  }
  
 this.http.fetch("http://localhost:5000/api/applicant/" + this.id, config).then(res=> res.json()).then(data=>{
   this.applicant = data.data
   console.log(data.data)
 } ); 
}

}
