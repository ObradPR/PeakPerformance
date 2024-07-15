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
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
    .join(' ');
}

String.prototype.appendArgument = appendArgument;
String.prototype.capitalize = capitalize;

export {};
