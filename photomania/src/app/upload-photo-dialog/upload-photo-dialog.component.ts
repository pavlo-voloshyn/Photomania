import { FileService } from './../services/file.service';
import { HttpClient, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatChipInputEvent } from '@angular/material/chips';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-upload-photo-dialog',
  templateUrl: './upload-photo-dialog.component.html',
  styleUrls: ['./upload-photo-dialog.component.scss']
})
export class UploadPhotoDialogComponent implements OnInit {
 // Variable to store shortLink from api response
 shortLink: string = "";
 loading: boolean = false; // Flag variable
 file!: File;

 // Inject service
 constructor(private fileService: FileService,
  public dialogRef: MatDialogRef<UploadPhotoDialogComponent>) { }

 ngOnInit(): void {
 }

 addOnBlur = true;
 readonly separatorKeysCodes = [ENTER, COMMA] as const;
 tags: string[] = [];

 add(event: MatChipInputEvent): void {
   const value = (event.value || '').trim();

   // Add our fruit
   if (value) {
     this.tags.push(value);
   }

   // Clear the input value
   event.chipInput!.clear();
 }

 remove(tag: string): void {
   const index = this.tags.indexOf(tag);

   if (index >= 0) {
     this.tags.splice(index, 1);
   }
 }

 // On file Select
 onChange(event: any) {
     this.file = event.target.files[0];
 }

 // OnClick of button Upload
 onUpload() {
     this.loading = !this.loading;
     console.log(this.file);
     this.fileService.upload(this.file, this.tags).subscribe(
         (event: any) => {
             if (typeof (event) === 'object') {
                console.log(event);
                 // Short link via api response
                 this.shortLink = event.link;

                 this.loading = false; // Flag variable
                 this.dialogRef.close();
             }
         }
     );
 }
}
