import { MainGalleryComponent } from './main-gallery/main-gallery/main-gallery.component';
import { LogupComponent } from './logup/logup/logup.component';
import { LoginComponent } from './login/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path:  '', component:  MainGalleryComponent, canActivate: [AuthGuard]},
  { path:  'login', component:  LoginComponent},
  { path:  'logup', component:  LogupComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
