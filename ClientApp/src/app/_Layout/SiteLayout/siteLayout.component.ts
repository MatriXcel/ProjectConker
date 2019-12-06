import { Component, OnInit, Renderer2, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'site-layout',
  templateUrl: './siteLayout.component.html',
  styleUrls: ['./siteLayout.component.css']


})
export class SiteLayoutComponent implements OnInit {

  constructor(
    private _renderer2: Renderer2,
    @Inject(DOCUMENT) private _document: Document
  ) { }

  ngOnInit() {

    let script = this._renderer2.createElement('script');
    script.type = `text/javascript`;
    script.text = `
        $(document).ready(function () {

          function slideSideBar() {
              $('.toggle').toggleClass('active');
              $('.side-nav').toggleClass('inactive');
              $('.page-container').toggleClass('extended');
              $('.overlayed').toggleClass('enabled');
          }

          $('.toggle').click(function () {
              slideSideBar();
          })
          $('.side-nav-content a').click(function () {
              slideSideBar();
          })

          $('.search-button').click(function () {
              $('.site-header').toggleClass('extended');
              $('.search').toggleClass('extended');
          })
      })
    `;

    this._renderer2.appendChild(this._document.body, script);
  }
}