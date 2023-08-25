import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  // injecting the router because we'll navigate users that get the error into our error components
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    // handle returns an Observable<HttpEvent<any>>.. We'll use rxJS to handle this which is the pipe method
    // In the pipe method we can do anything to an observable before we pass it onto our other components
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error) {
          if (error.status === 400) {
            this.toastr.error(error.error.message, error.status.toString());
          }

          if (error.status === 401) {
            this.toastr.error(error.error.message, error.status.toString());
          }

          if (error.status === 404) {
            this.router.navigateByUrl('/not-found');
          }

          if (error.status === 500) {
            this.router.navigateByUrl('/server-error');
          }
        }
        return throwError(() => new Error(error.message));
      })
    );
  }
}
