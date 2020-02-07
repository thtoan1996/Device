import { Pipe, PipeTransform } from '@angular/core';
//import {  } from 'rxjs/internal/scheduler/async';
import { async, TestBed } from '@angular/core/testing';
import { TestComponent } from './test.component';
import { TranslatePipe } from '@ngx-translate/core';

@Pipe({
  name: 'translate'
})
export class TranslatePipeMock implements PipeTransform {
  public name = 'translate';

  public transform(query: string, ...args: any[]): any {
    return query;
  }
}
describe('TestComponent', () => {
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [
            TestComponent,
          TranslatePipeMock // Add it to declarations
        ],
        // provide TranslatePipeMock
        providers: [
          {
            provide: TranslatePipe,
            useClass: TranslatePipeMock
          }
        ]
      }).compileComponents();
    }));
});
// /* tslint:disable:no-unused-variable */
// import { async, ComponentFixture, TestBed } from '@angular/core/testing';
// import { By } from '@angular/platform-browser';
// import { DebugElement } from '@angular/core';
// import {HttpClient} from "@angular/common/http";
// import { TestComponent } from './test.component';
// import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
// import {TranslateLoader, TranslateModule, TranslateService} from "@ngx-translate/core";
// import { createTranslateLoader } from 'src/app/app.module';
// //import { TestComponent } from 'src/app/app.component';

// const TRANSLATIONS_EN = require('../../../assets/i18n/en-US.json');
// const TRANSLATIONS_FR = require('../../../assets/i18n/fr-FR.json');
// describe('TestComponent', () => {
//   let translate: TranslateService;
//   let http: HttpTestingController;

//   beforeEach(async(() => {
//     TestBed.configureTestingModule({
//       declarations:[TestComponent],
//       imports:[
//         HttpClientTestingModule,
//         TranslateModule.forRoot({
//           loader:{
//             provide: TranslateLoader,
//             useFactory: createTranslateLoader,
//             deps: [HttpClient]
//           }
//         })
//       ],
//       providers:[TranslateService]
//     }).compileComponents();
//     translate = TestBed.get(TranslateService);
//     http = TestBed.get(HttpTestingController);
//   }));

//   it('should create the app', async(() => {
//     const fixture = TestBed.createComponent(TestComponent);
//     const app = fixture.debugElement.componentInstance;
//     expect(app).toBeTruthy();
//   }));
//   it('should load translation', async(() => {
//     spyOn(translate,'getBrowserLang').and.returnValue('en');
//     const fixture = TestBed.createComponent(TestComponent);
//     const compiled = fixture.debugElement.nativeElement;

//     expect(compiled.querySelector('h2').textContent).toEqual('');
//     http.expectOne('../../../assets/i18n/en-US.json').flush(TRANSLATIONS_EN);
//     http.expectNone('../../../assets/i18n/fr-FR.json');

//     http.verify();
//     fixture.detectChanges();

//     expect(compiled.querySelector('h2').textContent).toEqual(TRANSLATIONS_EN.HOME.TITLE);
//     translate.use('fr');
//     http.expectOne('src/assets/i18n/fr-FR.json').flush(TRANSLATIONS_FR);

//     http.verify();

//     expect(compiled.querySelector('h2').textContent).toEqual(TRANSLATIONS_EN.HOME.TITLE);
//     fixture.detectChanges();
//     expect(compiled.querySelector('h2').textContent).toEqual(TRANSLATIONS_FR.HOME.TITLE);
//   }));
// });