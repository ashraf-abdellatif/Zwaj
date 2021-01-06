import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from 'ngx-gallery';
import { error } from 'protractor';
import { User } from 'src/app/_Model/user';
import { UserService } from 'src/app/_services/User.service';

@Component({
  selector: 'app-Member-Detail',
  templateUrl: './Member-Detail.component.html',
  styleUrls: ['./Member-Detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  user: User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  constructor(private userService: UserService , private root: ActivatedRoute) { }

  ngOnInit() {
    this.LoadUserData(); 
  }
  LoadUserData() {
    this.userService.GetByID(+this.root.snapshot.params['id']).subscribe(
      (user: User) => {
        this.user = user;
        this.LoadUserImages();
      },
      (error) => { console.log(error); }
    );
  }
  LoadUserImages()
  {
    this.galleryOptions = [
      {
          width: '600px',
          height: '400px',
          thumbnailsColumns: 4,
          imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
          breakpoint: 800,
          width: '100%',
          height: '600px',
          imagePercent: 80,
          thumbnailsPercent: 20,
          thumbnailsMargin: 20,
          thumbnailMargin: 20
      },
      // max-width 400
      {
          breakpoint: 400,
          preview: false
      }
  ];
  this.galleryImages = [
    {
        small: this.user.photoUrl,
        medium: this.user.photoUrl,
        big: this.user.photoUrl
    },
    {
        small: this.user.photoUrl,
        medium: this.user.photoUrl,
        big: this.user.photoUrl
    },
    {
        small: this.user.photoUrl,
        medium: this.user.photoUrl,
        big: this.user.photoUrl
    }
];
  }
}
