import js from '@eslint/js';
import globals from 'globals';
import reactHooks from 'eslint-plugin-react-hooks';
import react from 'eslint-plugin-react';
import eslintComments from 'eslint-plugin-eslint-comments';
import reactRefresh from 'eslint-plugin-react-refresh';
import tseslint from 'typescript-eslint';

export default tseslint.config(
  { ignores: ['dist'] },
  {
    settings: {
      react: { version: 'detect' },
    }
  },
  {
    extends: [js.configs.recommended, ...tseslint.configs.strictTypeChecked],
    files: ['**/*.{ts,tsx}'],
    languageOptions: {
      ecmaVersion: 2020,
      globals: globals.browser,
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
    },
    plugins: {
      'react': react,
      'react-hooks': reactHooks,
      'react-refresh': reactRefresh,
      'eslint-comments': eslintComments,
    },
    rules: {
      ...reactHooks.configs.recommended.rules,
      ...react.configs.recommended.rules,
      ...react.configs['jsx-runtime'].rules,

      ...eslintComments.configs.recommended.rules,
      'eslint-comments/require-description': 'error',

      'react-refresh/only-export-components': [
        'warn',
        { allowConstantExport: true },
      ],

      // We like this rule in general, but are filtering out arrow shorthands, since they are so common
      '@typescript-eslint/no-confusing-void-expression': [
        'error',
        { ignoreArrowShorthand: true },
      ],

      // this rule seems buggy or nonsensical? It is going off constantly on generics, where it claims it shouldn't be.
      '@typescript-eslint/no-invalid-void-type': 'off',
    },
  },
)
