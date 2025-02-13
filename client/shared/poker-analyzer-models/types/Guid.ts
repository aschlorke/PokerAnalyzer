export type Guid = string;
export const EmptyGuid = "00000000-0000-0000-0000-000000000000";

function isValidGuid(str: string): str is Guid {
  return /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/.test(
    str
  );
}

export type NominalKey<T extends string> = { [K in `__${T}`]: never };
export type Key<T extends string> = Guid & NominalKey<T>;

export function toPrimaryKey<T extends Guid>(input: Guid | string) {
  if (!isValidGuid(input)) {
    throw Error("Invalid Guid");
  }
  return input as T;
}

export function generatePrimaryKey<T extends Guid>() {
  const guid = crypto.randomUUID();
  return toPrimaryKey<T>(guid);
}
