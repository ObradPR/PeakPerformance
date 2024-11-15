declare global {
  interface String {
    appendArgument(this: string, ...args: string[]): string;
    capitalize(this: string): string;
  }
}

function appendArgument(this: string, ...args: string[]): string {
  return `${this} ${args.join(' ')}`.trim();
}

function capitalize(this: string): string {
  return this.split(' ')
    .map((_) => _.charAt(0).toUpperCase() + _.slice(1).toLowerCase())
    .join(' ');
}

String.prototype.appendArgument = appendArgument;
String.prototype.capitalize = capitalize;

function createRoutePath(...args: (string | number)[]): string {
  return args
    .filter(_ => _ !== null && _ !== undefined && _ !== '')
    .join('/');
}

export {
  createRoutePath
};