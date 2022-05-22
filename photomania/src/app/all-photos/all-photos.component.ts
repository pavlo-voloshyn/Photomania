import { MatDialog } from '@angular/material/dialog';
import { UploadPhotoDialogComponent } from './../upload-photo-dialog/upload-photo-dialog.component';
import { TokenService } from './../services/token.service';
import { FileService } from './../services/file.service';
import { Photo } from './../models/photo.interface';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-photos',
  templateUrl: './all-photos.component.html',
  styleUrls: ['./all-photos.component.scss']
})
export class AllPhotosComponent implements OnInit {
  baseUrl = "http://localhost:5166/";
  items: Photo[] = []
  isAdmin = false;
  tag = ''

  addedItems: Photo[] = []

  constructor(private fileService: FileService, private tokenService: TokenService,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.fileService.getAll().subscribe(res => {
      console.log(res)
      this.items = res;
    })
    this.isAdmin = this.tokenService.getRole() == 'Admin';

    this.fileService.getMyPhotos().subscribe(res => {
      this.addedItems = res
    })
  }

  onClickPlus(imgId?: string): void {
    console.log(imgId)
    this.fileService.addFavorite(imgId).subscribe((res)=> {
      console.log(res)

    this.fileService.getMyPhotos().subscribe(res => {
      this.addedItems = res
    })
    }, err => {
      console.log(err)
    })
  }

  isVisible(item: Photo): boolean {
    if(this.tag == '') {
      return true;
    }

    if(item.tags.includes(this.tag)) {
      return true;
    } else {
      return false;
    }
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(UploadPhotoDialogComponent, {
      width: '50%',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.fileService.getAll().subscribe(res => {
        console.log(res)
        this.items = res;
      })
    });
  }

  isAdded(item: Photo): boolean {
    if(this.addedItems.find(x => x.id == item.id)) {
      return true;
    } else {
      return false;
    }
  }
}
