"use strict";(self.webpackChunkclient=self.webpackChunkclient||[]).push([[481],{3481:(A,p,i)=>{i.r(p),i.d(p,{AccountModule:()=>S});var u=i(6895),a=i(9838),r=i(433),g=i(8372),f=i(5698),v=i(3900),h=i(4004),b=i(8746),t=i(1571),c=i(9479),d=i(4015);function C(e,s){if(1&e&&(t.TgZ(0,"li"),t._uU(1),t.qZA()),2&e){const l=s.$implicit;t.xp6(1),t.hij(" ",l," ")}}function y(e,s){if(1&e&&(t.TgZ(0,"ul",10),t.YNc(1,C,2,1,"li",11),t.qZA()),2&e){const l=t.oxw();t.xp6(1),t.Q6J("ngForOf",l.errors)}}const x=[{path:"login",component:(()=>{var e;class s{constructor(o,n,m){this.accountService=o,this.router=n,this.activatedRoute=m,this.loginForm=new r.cw({email:new r.NI("",[r.kI.required,r.kI.email]),password:new r.NI("",r.kI.required)}),this.returnUrl=this.activatedRoute.snapshot.queryParams.returnUrl||"/shop"}onSubmit(){this.accountService.login(this.loginForm.value).subscribe({next:()=>this.router.navigateByUrl(this.returnUrl)})}}return(e=s).\u0275fac=function(o){return new(o||e)(t.Y36(c.B),t.Y36(a.F0),t.Y36(a.gz))},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-login"]],decls:11,vars:7,consts:[[1,"d-flex","justify-content-center","mt-5"],[1,"col-3"],[3,"formGroup","ngSubmit"],[1,"text-center","mb-4"],[1,"mb-3"],[3,"formControl","label"],[3,"formControl","type","label"],[1,"d-grid"],["type","submit",1,"btn","btn-lg","btn-primary","mt-3",3,"disabled"]],template:function(o,n){1&o&&(t.TgZ(0,"div",0)(1,"div",1)(2,"form",2),t.NdJ("ngSubmit",function(){return n.onSubmit()}),t.TgZ(3,"div",3)(4,"h1",4),t._uU(5,"Login"),t.qZA()(),t._UZ(6,"app-text-input",5)(7,"app-text-input",6),t.TgZ(8,"div",7)(9,"button",8),t._uU(10,"Sign in"),t.qZA()()()()()),2&o&&(t.xp6(2),t.Q6J("formGroup",n.loginForm),t.xp6(4),t.Q6J("formControl",n.loginForm.controls.email)("label","Email Address"),t.xp6(1),t.Q6J("formControl",n.loginForm.controls.password)("type","password")("label","Password"),t.xp6(2),t.Q6J("disabled",n.loginForm.invalid))},dependencies:[r._Y,r.JJ,r.JL,r.oH,r.sg,d.t]}),s})()},{path:"register",component:(()=>{var e;class s{constructor(o,n,m){this.fb=o,this.accountService=n,this.router=m,this.errors=null,this.complexPassword="(?=^.{6,10}$)(?=.*d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*s).*$",this.registerForm=this.fb.group({displayName:["",r.kI.required],email:["",[r.kI.required,r.kI.email],[this.validateEmailNotTaken()]],password:["",[r.kI.required,r.kI.pattern(this.complexPassword)]]})}onSubmit(){this.accountService.register(this.registerForm.value).subscribe({next:()=>this.router.navigateByUrl("/shop"),error:o=>this.errors=o.errors})}validateEmailNotTaken(){return o=>o.valueChanges.pipe((0,g.b)(1e3),(0,f.q)(1),(0,v.w)(()=>this.accountService.checkEmailExists(o.value).pipe((0,h.U)(n=>n?{emailExists:!0}:null),(0,b.x)(()=>o.markAsTouched()))))}}return(e=s).\u0275fac=function(o){return new(o||e)(t.Y36(r.qu),t.Y36(c.B),t.Y36(a.F0))},e.\u0275cmp=t.Xpm({type:e,selectors:[["app-register"]],decls:13,vars:10,consts:[[1,"d-flex","justify-content-center","mt-5"],[1,"col-3"],[3,"formGroup","ngSubmit"],[1,"text-center","mb-4"],[1,"mb-3"],[3,"formControl","label"],[3,"formControl","type","label"],["class","text-danger list-unstyled",4,"ngIf"],[1,"d-grid"],["type","submit",1,"btn","btn-lg","btn-primary","mt-3",3,"disabled"],[1,"text-danger","list-unstyled"],[4,"ngFor","ngForOf"]],template:function(o,n){1&o&&(t.TgZ(0,"div",0)(1,"div",1)(2,"form",2),t.NdJ("ngSubmit",function(){return n.onSubmit()}),t.TgZ(3,"div",3)(4,"h1",4),t._uU(5,"Sign up"),t.qZA()(),t._UZ(6,"app-text-input",5)(7,"app-text-input",5)(8,"app-text-input",6),t.YNc(9,y,2,1,"ul",7),t.TgZ(10,"div",8)(11,"button",9),t._uU(12,"Sign Up"),t.qZA()()()()()),2&o&&(t.xp6(2),t.Q6J("formGroup",n.registerForm),t.xp6(4),t.Q6J("formControl",n.registerForm.controls.displayName)("label","Display Name"),t.xp6(1),t.Q6J("formControl",n.registerForm.controls.email)("label","Email Address"),t.xp6(1),t.Q6J("formControl",n.registerForm.controls.password)("type","password")("label","Password"),t.xp6(1),t.Q6J("ngIf",n.errors),t.xp6(2),t.Q6J("disabled",n.registerForm.invalid))},dependencies:[u.sg,u.O5,r._Y,r.JJ,r.JL,r.oH,r.sg,d.t]}),s})()}];let F=(()=>{var e;class s{}return(e=s).\u0275fac=function(o){return new(o||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[a.Bz.forChild(x),a.Bz]}),s})();var J=i(4466);let S=(()=>{var e;class s{}return(e=s).\u0275fac=function(o){return new(o||e)},e.\u0275mod=t.oAB({type:e}),e.\u0275inj=t.cJS({imports:[u.ez,F,J.m]}),s})()}}]);