import { Router } from '@angular/router';
import { TokenService } from './../../services/token.service';
import { UploadPhotoDialogComponent } from './../../upload-photo-dialog/upload-photo-dialog.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-main-gallery',
  templateUrl: './main-gallery.component.html',
  styleUrls: ['./main-gallery.component.scss']
})
export class MainGalleryComponent implements OnInit {

  constructor(
    private tokenService: TokenService,
    private router: Router,) { }

  isAllPhotos = true;
  welcome = ''
  isAdmin = false;

  ngOnInit(): void {
    this.welcome = this.tokenService.getUserName();
    this.isAdmin = this.tokenService.getRole() == 'Admin'
  }

  onClickMyPhotos(): void {
    this.isAllPhotos = false;
  }

  onClickAllPhotos(): void {
    this.isAllPhotos = true;
  }

  onClickLogout(): void {
    this.tokenService.clearStore();
    this.router.navigate(['login'])
  }

}
