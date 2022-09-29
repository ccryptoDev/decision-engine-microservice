import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreditScoreComponent } from './credit-score/credit-score.component';
import { RulesComponent } from './rules/rules.component';
import { MasterCreateScoreComponent } from './master-create-score/master-create-score.component';

const routes: Routes = [
  { path:'rules', component: RulesComponent},
  { path:'creditscore', component: CreditScoreComponent},
  { path:'mastercreditscore', component: MasterCreateScoreComponent},
  {path: '', redirectTo: "rules", pathMatch: 'full'},
  {path: '**', redirectTo: "rules", pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
