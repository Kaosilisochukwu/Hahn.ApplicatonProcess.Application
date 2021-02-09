import { IApplicants } from './applicants-service';
import { autoinject } from 'aurelia-framework'
import {HttpClient, json} from 'aurelia-fetch-client';
import {RouterConfiguration, Router} from 'aurelia-router';

@autoinject
export class Details{
  
  id;
  applicant: IApplicants
  controller: any
  http: HttpClient;
constructor(http:HttpClient, private router:Router){
  this.http = http;
  this.router = router;
  //this.getApplicants();
  
}

delete():void{
  console.log(this.id)
  const config = {
    headers: {
      "Content-Type":"application/json"
    },
    method: "delete",
  }
  
 this.http.fetch("http://localhost:5000/api/applicant/" + this.id, config).then(res=> res.json()).then(data=>{
   this.applicant = data.data
   console.log(data.data)
  } );  
  this.router.navigate("/")
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
