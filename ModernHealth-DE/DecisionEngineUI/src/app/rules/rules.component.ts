import { Component, OnInit, TemplateRef } from '@angular/core';

import { NgxSpinnerService } from "ngx-spinner";
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-rules',
  templateUrl: './rules.component.html',
  styleUrls: ['./rules.component.scss']
})
export class RulesComponent implements OnInit {

  


  url:any = "https://rules-engine-api.alchemylms.com"
  LoadRuleDescription_value:any = [];
  LoadRules_value:any = [];
  f1:any = {}
  f2:any = {}
  modalRef: BsModalRef;
  constructor(private spinner: NgxSpinnerService,private http:HttpClient,private modalService: BsModalService) {
    //this.spinner.show();
    
    
  }

  ngOnInit(): void {
    this.LoadRules()
    this.LoadRuleDescription()
  }

  number(data){
    return data.target.value = data.target.value.replace(/[^0-9.]/g,'')
  }

  setLoadRules_value(data,template: TemplateRef<any>){
    
    if(data.disabled==true){
      data.disabled = 't'
    }else{
      data.disabled = 'f'
    }
    this.f2 = data

    this.modalRef = this.modalService.show(template);
  }
  setLoadRuleDescription_value(){
    if(this.LoadRuleDescription_value.length>0){
      this.f1.rule_id= this.LoadRuleDescription_value[0].id.toString()
    }
    this.f1.declinedif='Greater than'
    this.f1.value=0
    this.f1.disabled='t'    
  }

  get(url){
    let httpHeaders = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Access-Control-Allow-Origin','*')
    let options = {
        headers: httpHeaders
    };
    
    
     return this.http.get(this.url+url,options)
  }

  post(url,data){
    let httpHeaders = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Access-Control-Allow-Origin','*')
    let options = {
        headers: httpHeaders
    };
    
     return this.http.post(this.url+url,data,options)
  }

  LoadRules(){
    this.spinner.show();
    this.get('/api/Rules/LoadRules').subscribe(res=>{
     this.LoadRules_value = res
     this.spinner.hide()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }
  

  LoadRuleDescription(){
    this.spinner.show();
    this.get('/api/Rules/LoadRuleDescription').subscribe(res=>{
     this.LoadRuleDescription_value = res
     this.setLoadRuleDescription_value()
     this.spinner.hide()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }

  onSubmit(){
    this.spinner.show();
    let data = {
      "rule_id": Number(this.f1.rule_id),
      "declinedif": this.f1.declinedif,
      "value": Number(this.f1.value)
    }
    if(this.f1.disabled=='t'){
      data['disabled'] = true
    }else{
      data['disabled'] = false
    }
    this.post("/api/Rules/addRule",data).subscribe(res=>{
      this.spinner.hide()
      this.close()
      this.LoadRules()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }

  openaddproductrulemodal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  onSubmit1(){
    let data = {
      "id": this.f2.id,
      "rule_id": this.f2.rule_id,
      "declinedif": this.f2.declinedif,
      "value": Number(this.f2.value)
    }
    if(this.f2.disabled=='t'){
      data['disabled'] = true
    }else{
      data['disabled'] = false
    }
    this.post("/api/Rules/updateRule",data).subscribe(res=>{
      this.spinner.hide()
      this.close()
      this.LoadRules()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }

  close(): void {
    this.modalRef.hide();
  }
  


}
