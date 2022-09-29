import { Component, OnInit,TemplateRef,ViewChild } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-credit-score',
  templateUrl: './credit-score.component.html',
  styleUrls: ['./credit-score.component.scss']
})
export class CreditScoreComponent implements OnInit {

  url:any = "https://rules-engine-api.alchemylms.com"
  data:any = [];
  col_id:any = [];
  row_id:any = [];
  rows:any = {};
  a_z:any = 'abcdefghijklmnopqrstuvwxyz'.toUpperCase().split('');
  f1:any = {"gradeValue":"A","scoreId":"-1","incomeId":"-1"}
  f2:any = {}
  updateform:any=false;
  modalRef: BsModalRef;
  message:any = [];
  color = {
    a:"#00ffff",
    b:"#7fffd4",
    c:"#ffebcd",
    d:"#0000ff",
    e:"#8a2be2",
    f:"#a52a2a",
    g:"#deb887",
    h:"#5f9ea0",
    i:"#7fff00",
    j:"#d2691e",
    k:"#6495ed",
    l:"#fff8dc",
    m:"#dc143c",
    n:"#00ffff",
    o:"#008b8b",
    p:"#b8860b",
    q:"#a9a9a9",
    r:"#006400",
    s:"#a9a9a9",
    t:"#bdb76b",
    u:"#8b008b",
    v:"#556b2f",
    w:"#ff8c00",
    x:"#9932cc",
    y:"#8b0000",
    z:"#2f4f4f"
  }
  @ViewChild('messagebox', { read: TemplateRef }) messagebox:TemplateRef<any>;
  //selectId = -1;
  constructor(private spinner: NgxSpinnerService,private http:HttpClient,private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getlist()
    //this.getdata()
  }

  number(data){
    return data.target.value = data.target.value.replace(/[^0-9.]/g,'')
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

  msg(msg){
    this.message = msg
    this.modalRef = this.modalService.show(this.messagebox);
  }

  close(): void {
    this.modalRef.hide();
  }


  getlist(){
    this.spinner.show()
    this.get("/api/Score/scores").subscribe(res=>{
      this.spinner.hide()
      let scores:any = res
      scores = scores.sort((a, b)=> b.fromScore-a.fromScore)
      for (let i = 0; i < scores.length; i++) {
        this.row_id.push({
          id:scores[i].id,
          value:scores[i].fromScore.toString()+"-"+scores[i].toScore.toString()
        })
      }
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
    this.spinner.show()
    this.get("/api/Income/incomes").subscribe(res=>{
      this.spinner.hide()
      let incomes:any = res
      incomes = incomes.sort((a, b)=> b.minIncome-a.minIncome)
      for (let i = 0; i < incomes.length; i++) {
        this.col_id.push({
          id:incomes[i].id,
          value:incomes[i].minIncome.toString()+"-"+incomes[i].maxIncome.toString()
        })
      }
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
    this.getdata()
  }


  getdata(){
    this.spinner.show();
    this.get('/api/GradeAPR/grades').subscribe(res=>{
     this.data = res
     this.spinner.hide()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }


  add(){
    this.spinner.show()
    let data = {}
    this.f1['scoreId'] = +this.f1['scoreId']
    this.f1['incomeId'] = +this.f1['incomeId']
    if(this.f1['scoreId']>0){
      if(this.f1['incomeId']>0){
        this.f1['apr'] = +this.f1['apr']
        data['scoreId'] = this.f1['scoreId']
        data['incomeId'] = this.f1['incomeId']
        data['apr'] = this.f1['apr']
        data['gradeValue'] = this.f1['gradeValue']
        this.post('/api/GradeAPR/add',data).subscribe(res=>{
          this.spinner.hide()
          window.location.reload()
        },err=>{
          this.spinner.hide()
          console.log(err)
        })
      }else{
        this.spinner.hide()
        this.msg(["Please Select Income"])
      }
    }else{
      this.spinner.hide()
      this.msg(["Please Select Score"])
    }
  }

  check(){
    let check = this.data
      this.f1['scoreId'] = +this.f1['scoreId']
      this.f1['incomeId'] = +this.f1['incomeId']
    if(this.f1['scoreId']>0){
      if(this.f1['incomeId']>0){
        let j = 0;
        for (let i = 0; i < check.length; i++) {
          
          if(check[i]['scoreId']==this.f1['scoreId'] && check[i]['incomeId']==this.f1['incomeId']){
            j=1;
            this.updateform = true
            this.f1["apr"] = check[i]['apr']
            this.f1["gradeValue"] = check[i]['gradeValue']
            this.f1["id"] = check[i]['id']
            i = check.length+1
          }else{
            this.updateform = false
            this.f1["apr"] = ''
          this.f1["gradeValue"] = 'A'
          }
        }
       
       
      }else{
        this.updateform = false
        this.updateform = false
          this.f1["apr"] = ''
          this.f1["gradeValue"] = 'A'
      }
    }else{
      this.updateform = false
      this.updateform = false
          this.f1["apr"] = ''
          this.f1["gradeValue"] = 'A'
    }
  }

  

  update(){
    this.f1['apr'] = +this.f1['apr']
    this.spinner.show()
    this.post('/api/GradeAPR/update',this.f1).subscribe(res=>{
      this.spinner.hide()
      window.location.reload()
    },err=>{
      this.spinner.hide()
      console.log(err)
    })
  }






































  // add(){
  //   if(isNaN(Number(this.f1['toScore']))){
  //     this.f1['toScore'] = 0
  //   }
  //   if(isNaN(Number(this.f1['maxIncome']))){
  //     this.f1['maxIncome'] = 0
  //   }
  //   this.f1['fromScore'] = Number(this.f1['fromScore'])
  //   this.f1['toScore'] = Number(this.f1['toScore'])
  //   this.f1['maxIncome'] = Number(this.f1['maxIncome'])
  //   this.f1['minIncome'] = Number(this.f1['minIncome'])
  //   this.f1['apr'] = Number(this.f1['apr'])
  //   this.spinner.show();
  //   this.post('/api/Grade/add',this.f1).subscribe(res=>{
  //    this.spinner.hide()
  //    this.getdata()
  //   },err=>{
  //     this.spinner.hide()
  //     console.log(err)
  //   })
  // }

  // update(){
  //   if(isNaN(Number(this.f1['toScore']))){
  //     this.f1['toScore'] = 0
  //   }
  //   if(isNaN(Number(this.f1['maxIncome']))){
  //     this.f1['maxIncome'] = 0
  //   }
  //   this.f1['fromScore'] = Number(this.f1['fromScore'])
  //   this.f1['toScore'] = Number(this.f1['toScore'])
  //   this.f1['maxIncome'] = Number(this.f1['maxIncome'])
  //   this.f1['minIncome'] = Number(this.f1['minIncome'])
  //   this.f1['apr'] = Number(this.f1['apr'])
    

  //   this.spinner.show();
  //   this.put('/api/Grade/update',this.f1).subscribe(res=>{
  //    this.spinner.hide()
  //    this.getdata()
  //   },err=>{
  //     this.spinner.hide()
  //     console.log(err)
  //   })
  // }
  
  // getdata(){
  //   this.spinner.show();
  //   this.get('/api/Grade/grades').subscribe(res=>{
  //    this.data = res
  //    this.set()
  //    this.spinner.hide()
  //   },err=>{
  //     this.spinner.hide()
  //     console.log(err)
  //   })
  // }

  // set(){
  //   this.col_id = [];
  //   let key = [];
  //   let value = {};
  //   for (let i = 0; i < this.data.length; i++) {
  //     let a = "";
  //     let b = "";
  //     if(this.data[i]["minIncome"]){
  //       if(this.data[i]["maxIncome"]!=0 && this.data[i]["maxIncome"]!=null && this.data[i]["maxIncome"]!=""){
  //         a = this.data[i]["minIncome"].toString()+"-"+this.data[i]["maxIncome"].toString()
  //       }else{
  //         a = this.data[i]["minIncome"].toString()+"+"
  //       }
  //       b = this.data[i]["minIncome"]
  //     }
  //     if(!key.includes(b)){
  //       key.push(b)
  //       value[b]=a
  //     }
  //   }
  //   key = key.sort((a, b)=> b-a)
  //   for (let i = 0; i < key.length; i++) {
  //     this.col_id.push(value[key[i]])
  //   }
  //   this.row_id = [];
  //   key = [];
  //   value = {};
  //   for (let i = 0; i < this.data.length; i++) {
  //     let a = "";
  //     let b = "";
  //     if(this.data[i]["fromScore"]){
  //       if(this.data[i]["toScore"]!=0 && this.data[i]["toScore"]!=null && this.data[i]["toScore"]!=""){
  //         a = this.data[i]["fromScore"].toString()+"-"+this.data[i]["toScore"].toString()
  //       }else{
  //         a = this.data[i]["fromScore"].toString()+"+"
  //       }
  //       b = this.data[i]["fromScore"]
  //     }
  //     if(!key.includes(b)){
  //       key.push(b)
  //       value[b]=a
  //     }
  //   }
  //   key = key.sort((a, b)=> b-a)
  //   for (let i = 0; i < key.length; i++) {
  //     this.row_id.push(value[key[i]])
  //   }

  //   for (let i = 0; i < this.row_id.length; i++) {
  //     this.rows[this.row_id[i]] = {};
  //     for (let j = 0; j < this.col_id.length; j++) {
  //       this.rows[this.row_id[i]][this.col_id[j]] = {"gradeValue":"","apr":""}
  //     }
  //   }

  //   for (let i = 0; i < this.data.length; i++) {
  //     let a = "";
  //     let b = "";
  //     if(this.data[i]["fromScore"]){
  //       if(this.data[i]["toScore"]!=0 && this.data[i]["toScore"]!=null && this.data[i]["toScore"]!=""){
  //         a = this.data[i]["fromScore"].toString()+"-"+this.data[i]["toScore"].toString()
  //       }else{
  //         a = this.data[i]["fromScore"].toString()+"+"
  //       }
  //     }
  //     if(this.data[i]["minIncome"]){
  //       if(this.data[i]["maxIncome"]!=0 && this.data[i]["maxIncome"]!=null && this.data[i]["maxIncome"]!=""){
  //         b = this.data[i]["minIncome"].toString()+"-"+this.data[i]["maxIncome"].toString()
  //       }else{
  //         b = this.data[i]["minIncome"].toString()+"+"
  //       }
  //     }
  //     this.rows[a][b]["gradeValue"] = this.data[i]["gradeValue"]
  //     this.rows[a][b]["apr"] = this.data[i]["apr"]
  //     this.rows[a][b]["index"] = i
  //   }
  // }

 
 

}
