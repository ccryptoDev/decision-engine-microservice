import { Component, OnInit, TemplateRef,ViewChild } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-master-create-score',
  templateUrl: './master-create-score.component.html',
  styleUrls: ['./master-create-score.component.scss']
})
export class MasterCreateScoreComponent implements OnInit {
  url:any = "https://rules-engine-api.alchemylms.com"
  scores:any = [];
  incomes:any = [];
  f1:any = {};
  f2:any = {};
  modalRef: BsModalRef;
  message:any = [];
  scoreeditid = -1;
  incomeeditid = -1;
  @ViewChild('messagebox', { read: TemplateRef }) messagebox:TemplateRef<any>;
 
  constructor(private spinner: NgxSpinnerService,private http:HttpClient,private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getlist()
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

  // put(url,data){
  //   let httpHeaders = new HttpHeaders()
  //   .set('Content-Type', 'application/json')
  //   .set('Access-Control-Allow-Origin','*')
  //   let options = {
  //       headers: httpHeaders
  //   };
  //    return this.http.put(this.url+url,data,options)
  // }

  getlist(){
    this.spinner.show()
    this.get("/api/Score/scores").subscribe(res=>{
      this.spinner.hide()
      this.scores = res
      this.scores = this.scores.sort((a, b)=> b.fromScore-a.fromScore)
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
    this.spinner.show()
    this.get("/api/Income/incomes").subscribe(res=>{
      this.spinner.hide()
      this.incomes = res
      this.incomes = this.incomes.sort((a, b)=> b.minIncome-a.minIncome)
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }

  number(data){
    return data.target.value = data.target.value.replace(/[^0-9.]/g,'')
  }


  addscore(){
    this.spinner.show()
    this.f1['fromScore'] = +this.f1['fromScore']
    this.f1['toScore'] = +this.f1['toScore']
    if(this.f1['fromScore']<this.f1['toScore']){
      let j = 0;
      for (let i = 0; i < this.scores.length; i++) {
        if(this.scores[i]['fromScore']==this.f1['fromScore'] && this.scores[i]['toScore']==this.f1['toScore']){
          j = 1;
          i = this.scores.length+1;
        }       
      }
      if(j==1){
        this.spinner.hide()
        this.msg(["From Score: "+this.f1['fromScore'],"To Score: "+this.f1['toScore'],"Already Exists..."])
      }else{
        this.post("/api/Score/add",this.f1).subscribe(res=>{
          this.spinner.hide()
          window.location.reload()
        },err=>{
          this.spinner.hide()
          console.log(err)
        })
      }
    }else{
      this.spinner.hide()
      this.msg(["From Score < To Score","Ex: 100 < 150","Please Check Your Value"])
    }  
  }


  addincome(){
    this.spinner.show()
    this.f1['minIncome'] = +this.f1['minIncome']
    this.f1['maxIncome'] = +this.f1['maxIncome']
    if(this.f1['minIncome']<this.f1['maxIncome']){
      let j = 0;
      for (let i = 0; i < this.incomes.length; i++) {
        if(this.incomes[i]['minIncome']==this.f1['minIncome'] && this.incomes[i]['maxIncome']==this.f1['maxIncome']){
          j = 1;
          i = this.incomes.length+1;
        }       
      }
      if(j==1){
        this.spinner.hide()
        this.msg(["Min Income: "+this.f1['minIncome'],"Max Income: "+this.f1['maxIncome'],"Already Exists..."])
      }else{
        this.post("/api/Income/add",this.f1).subscribe(res=>{
          this.spinner.hide()
          window.location.reload()
        },err=>{
          this.spinner.hide()
          console.log(err)
        })
      }
    }else{
      this.spinner.hide()
      this.msg(["Min Income < Max Income","Ex: 100 < 150","Please Check Your Value"])
    }  
  }

  msg(msg){
    this.message = msg
    this.modalRef = this.modalService.show(this.messagebox);
  }

  close(): void {
    this.modalRef.hide();
  }

  scoreedit(d){
    this.f2 = d;
    this.scoreeditid = d.id;
  }

  scoreeditcolse(){
    this.scoreeditid = -1
    this.incomeeditid = -1
  }

  updatesocre(){
    this.spinner.show()
    this.f2['fromScore'] = +this.f2['fromScore']
    this.f2['toScore'] = +this.f2['toScore']
    if(this.f2['fromScore']<this.f2['toScore']){
      let j = 0;
      for (let i = 0; i < this.scores.length; i++) {
        if(this.scores[i]['fromScore']==this.f2['fromScore'] && this.scores[i]['toScore']==this.f2['toScore'] && this.scores[i]['id']!=this.f2['id']){
          j = 1;
          i = this.scores.length+1;
        }       
      }
      if(j==1){
        this.spinner.hide()
        this.msg(["From Score: "+this.f2['fromScore'],"To Score: "+this.f2['toScore'],"Already Exists..."])
      }else{
        this.post("/api/Score/update",this.f2).subscribe(res=>{
          this.spinner.hide()
          this.scoreeditid = -1
          this.incomeeditid = -1
          this.getlist()
        },err=>{
          this.spinner.hide()
          console.log(err)
        })
      }
    }else{
      this.spinner.hide()
      this.msg(["From Score < To Score","Ex: 100 < 150","Please Check Your Value"])
    }
  }

  scoredelete(d){
    this.spinner.show()
    this.post("/api/Score/delete/"+d.id,{}).subscribe(res=>{
      this.spinner.hide()
      this.getlist()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }

  incomeedit(d){
    this.f2 = d;
    this.incomeeditid = d.id;
  }

  incomeeditcolse(){
    this.incomeeditid = -1
    this.scoreeditid = -1
    
  }

  updateincome(){
    this.spinner.show()
    this.f2['minIncome'] = +this.f2['minIncome']
    this.f2['maxIncome'] = +this.f2['maxIncome']
    if(this.f2['minIncome']<this.f2['maxIncome']){
      let j = 0;
      for (let i = 0; i < this.incomes.length; i++) {
        if(this.incomes[i]['minIncome']==this.f2['minIncome'] && this.incomes[i]['maxIncome']==this.f2['maxIncome'] && this.incomes[i]['id']!=this.f2['id']){
          j = 1;
          i = this.incomes.length+1;
        }       
      }
      if(j==1){
        this.spinner.hide()
        this.msg(["Min Income: "+this.f2['minIncome'],"Max Income: "+this.f2['maxIncome'],"Already Exists..."])
      }else{
        this.post("/api/Income/update",this.f2).subscribe(res=>{
          this.spinner.hide()
          this.scoreeditid = -1
          this.incomeeditid = -1
          this.getlist()
        },err=>{
          this.spinner.hide()
          console.log(err)
        })
      }
    }else{
      this.spinner.hide()
      this.msg(["Min Income < Max Income","Ex: 100 < 150","Please Check Your Value"])
    }  
  }

 incomedelete(d){
    this.spinner.show()
    this.post("/api/Income/delete/"+d.id,{}).subscribe(res=>{
      this.spinner.hide()
      this.getlist()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }

}
